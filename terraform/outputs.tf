output "s3_bucket_name" {
  value = module.game.s3_bucket_name
}

output "index_html_url" {
  value = "http://${module.game.bucket_regional_domain_name}/index.html"
}