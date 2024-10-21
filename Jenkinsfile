pipeline {
    agent any

    tools {
        nodejs 'NodeJS-18' // Node.js 18, pastikan sudah terinstall di Jenkins
    }

    environment {
        dockerRegistryServiceConnection = 'devops-poc'
        imageRepository = 'nuek21/testing-node'
        tag = "${env.BUILD_ID}"
        containerName = 'node-app-container'
    }

    stages {
        stage('Checkout Code') {
            steps {
                // Mengambil source code dari Azure DevOps
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
            }
        }

        stage('Install Node.js Dependencies') {
            steps {
                dir('poc') {
                    // Install Node.js dependencies
                    sh 'npm install'
                }
            }
        }

        stage('Authenticate to npm') {
            steps {
                dir('poc') {
                    // Autentikasi dengan npm (pastikan file .npmrc disiapkan)
                    sh 'npm config set registry https://registry.npmjs.org/'
                }
            }
        }

        stage('Publish to npm') {
            steps {
                dir('poc') {
                    // Publish ke npm
                    sh 'npm publish'
                }
            }
        }

        stage('Build and Push Docker Image') {
            steps {
                dir('poc') {
                    script {
                        // Build Docker image
                        sh """
                        docker build -t ${dockerRegistryServiceConnection}/${imageRepository}:${tag} .
                        docker push ${dockerRegistryServiceConnection}/${imageRepository}:${tag}
                        """
                    }
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Run Docker container on port 3001
                    sh """
                    docker run -d -p 3001:3001 --name ${containerName} ${dockerRegistryServiceConnection}/${imageRepository}:${tag}
                    """
                }
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
