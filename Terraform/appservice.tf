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
  name                = "appservice-${var.project_name}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  client_affinity_enabled = true
  https_only = true

  site_config {
    always_on = true
    default_documents        = ["Default.htm","Default.html","Default.asp","index.htm","index.html","iisstart.htm","default.aspx","index.php","hostingstart.html",]
    dotnet_framework_version = "v6.0"
    scm_type                 = "VSTSRM"
    use_32_bit_worker_process = true
  }

  connection_string {
    name  = "sql-devsecops"
    type  = "SQLAzure"
    value = "Server=tcp:sql-devsecops.database.windows.net,1433;Initial Catalog=db-devsecops;User ID=admin@sql-devsecops;Password=P@ssw0rd123!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}