pipeline {
    agent any

    environment {
        // Set up Azure DevOps organization, project, and PAT
        ORGANIZATION = "ImmanuelSianturi"
        PROJECT = "Project-Poc"
        PAT = credentials('azureDevOpsPAT') // Menggunakan credentials dari Jenkins (pastikan sudah setup)
        BRANCH = "main" // Branch yang akan dijalankan
    }

    stages {
        stage('Choose Folder') {
            steps {
                script {
                    // Choose between poc or literature_backend folder
                    def folder = input message: 'Select Folder to Build', 
                                  parameters: [choice(name: 'FOLDER', choices: ['poc', 'literature_backend'], description: 'Choose the folder to build')]
                    env.FOLDER = folder // Set folder as an environment variable
                }
            }
        }

        stage('Trigger Pipeline') {
            steps {
                script {
                    def pipelineName = env.FOLDER == 'poc' ? "poc-pipeline" : "literature_backend-pipeline"
                    def apiUrl = "https://dev.azure.com/${ORGANIZATION}/${PROJECT}/_apis/pipelines?api-version=6.0"
                    def pipelineYamlPath = "/${env.FOLDER}/pipeline.yml"

                    // Construct the request body
                    def body = [
                        "resources": [
                            "repositories": [
                                "self": [
                                    "refName": "refs/heads/${BRANCH}",
                                    "path": pipelineYamlPath
                                ]
                            ]
                        ]
                    ]

                    // Trigger Azure DevOps pipeline using curl
                    sh """
                    curl -u :${PAT} \
                    -X POST -H "Content-Type: application/json" \
                    -d '${JsonOutput.toJson(body)}' \
                    ${apiUrl}
                    """
                }
            }
        }

        stage('Verify Pipeline Trigger') {
            steps {
                echo "Pipeline triggered for folder: ${env.FOLDER}"
            }
        }
    }

    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
