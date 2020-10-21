# Copy or rename this file to `env_[ENVIRONMENT_NAME].tfvars` and fill in the values below
# e.g. `cp example.tfvars env_dev.tfvars`
# Don't forget to pass -var-file="env_dev.tfvars" when running terraform

# Access config
aws_access_key       = ""
aws_secret_key       = ""

# AWS region to create resources in (unless not available)
aws_region = "ap-southeast-2"
# Unique identifier for this project. All resources will be tagged with this id. Also used for naming resources.
# Must be a simple A-Z0-9 string with optional dashes (-) or underscores (_)
# e.g. "pet-game"
project_id = "pet-game"
# Unique environment identifier. All resources will be tagged with this id. Also used for naming resources.
# Must be a simple A-Z0-9 string with optional dashes (-) or underscores (_)
# e.g. dev
environment_id = ""
# Unique identifier for this game. Used in naming resources.
# Must be a simple A-Z0-9 string with optional dashes (-)
# e.g. "bappy-flirb"
game_id = "bappy-flirb"