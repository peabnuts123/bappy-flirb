variable "project_id" {
  description = "Unique simple identifier for project. Must only use A-Z, 0-9, - or _ characters e.g. \"pet-game\""
  type        = string

  validation {
    condition     = can(regex("^[A-Za-z0-9-_]+$", var.project_id))
    error_message = "Variable `project_id` must only be characters A-Z (or a-z), 0-9, hypen (-) or underscore (_)."
  }
}
variable "environment_id" {
  description = "Unique simple identifier for environment. Must only use A-Z, 0-9, - or _ characters e.g. \"dev\" or \"test-2\""
  type        = string

  validation {
    condition     = can(regex("^[A-Za-z0-9-_]+$", var.environment_id))
    error_message = "Variable `environment_id` must only be characters A-Z (or a-z), 0-9, hypen (-) or underscore (_)."
  }
}
variable "game_id" {
  description = "Unique simple identifier for the game. Must only use A-Z, 0-9, - or _ characters e.g. \"bappy-flirb\""
  type        = string

  validation {
    condition     = can(regex("^[A-Za-z0-9-]+$", var.game_id))
    error_message = "Variable `game_id` must only be characters A-Z (or a-z), 0-9, or hypen (-)."
  }
}
