resource "aws_s3_bucket" "game" {
  bucket = local.s3_bucket_name
  acl    = "public-read"

  # AWS tags
  tags = {
    project = var.project_id
    environment = var.environment_id
  }
}
