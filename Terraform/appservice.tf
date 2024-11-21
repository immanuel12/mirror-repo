resource "azurerm_app_service_plan" "app_service_plan" {
  name                = "appserviceplan-${var.project_name}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "app_service" {
  name                = "app-service-${var.project_name}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

#   app_settings = {
#     "SOME_KEY" = "some-value"
#   }

  connection_string {
    name  = "Database"
    type  = "SQLServer"
    value = "Server=sql-devsecops.database.windows.net;Database=db-devsecops;User ID=sqladmin;Password=P@ssw0rd123!;Encrypt=true;TrustServerCertificate=false;Connection Timeout=30;"
  }
}