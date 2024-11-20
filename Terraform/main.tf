terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.0.0, < 4.0.0"
    }
  }
}

provider "azurerm" {
  features {}
}

# resource "azurerm_resource_group" "rg" {
#   location = var.location
#   name     = "rg-${var.project_name}"
# }