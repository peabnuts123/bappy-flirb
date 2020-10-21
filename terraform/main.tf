# Providers
provider "aws" {
  region     = var.aws_region
  access_key = var.aws_access_key
  secret_key = var.aws_secret_key
}

# Modules
module "game" {
  source = "./modules/game"

  project_id=var.project_id
  environment_id=var.environment_id
  game_id=var.game_id
}
