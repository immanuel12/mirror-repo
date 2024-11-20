###################################################################################################
### General
###################################################################################################
location         = "southeastasia"
zone             = 1
project_name     = "devsecops"

backend = {
    storage_account_name = "stagitdevsecops"
    resource_group_name  = "rg-terraform-tfstate"
    container_name       = "terraform"
}