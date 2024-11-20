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

terraform {
  backend "azurerm" {
    resource_group_name   = var.backend["resource_group_name"]
    storage_account_name  = var.backend["storage_account_name"]
    container_name        = var.backend["container_name"]
    key                   = "${var.project_name}-terraform.tfstate"
  }
}

resource "azurerm_resource_group" "rg" {
  location = var.location
  name     = "rg-${var.project_name}"
}