variable "location" {
  description = "location"
}

variable "project_name" {
  description = "Project Name"
}

variable "zone" {
  description = "Availability Zone"
}

variable "environment" {
  description = "Environment General"
}

variable "entity" {
  description = "Entity Short"
}

variable "aks" {
  type = any
}

variable "vnet" {
  type = any
}

variable "vm" {
  type = any
}

variable "environments" {
  description = "Environment Tagging"
}