#!/usr/bin/env bash

set -e;

# Prerequisites
#   - A WebGL build of game in the `<project_root>/build` folder
#   - AWS CLI

# Validate arguments
if [ -z "$1" ]
then
  echo "No S3 bucket name specified."
  echo "Usage: $0 (s3_bucket_name)"
  exit 1
fi

# Arguments
s3_bucket_name="${1}";

function exit_with_message_and_code() {
  code="$1";
  message="$2";
  echo "Error: ${message}";
  exit "$code";
}

cd build || exit_with_message_and_code 1 "Must run $0 from project root - ensure you have also built the project into <project_root>/build";

# Deploy pre-compressed content in phases
# Each phase is for a different combination of `content-type`/`content-encoding` headers

# Clear out / upload everything first
echo "[Phase 1] Sync everything"
aws s3 sync . "s3://${s3_bucket_name}" --acl 'public-read' --delete --profile 'petgame'

# Brotli-compressed files
# - general (upload everything brotli-compressed as "binary/octet-stream" by default)
echo "[Phase 2] Brotli-compressed files"
aws s3 cp . "s3://${s3_bucket_name}" \
  --exclude="*" --include="*.br" \
  --acl 'public-read' \
  --content-encoding br \
  --content-type="binary/octet-stream" \
  --metadata-directive REPLACE --recursive \
  --profile 'petgame';

# - javascript (ensure javascript has correct content-type)
echo "[Phase 3] Brotli-compressed JavaScript"
aws s3 cp . "s3://${s3_bucket_name}" \
  --exclude="*" --include="*.js.br" \
  --acl 'public-read' \
  --content-encoding br \
  --content-type="application/javascript" \
  --metadata-directive REPLACE --recursive \
  --profile 'petgame';

echo "Successfully deployed game";
