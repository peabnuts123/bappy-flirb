output "s3_bucket_name" {
  value = aws_s3_bucket.game.bucket
}

output "bucket_regional_domain_name" {
  value = aws_s3_bucket.game.bucket_regional_domain_name
}