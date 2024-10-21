pipeline {
    agent any

    tools {
        nodejs 'NodeJS' // Sesuaikan dengan nama Node.js yang dikonfigurasi
    }

    stages {
        stage('Clone Repository') {
            steps {
                // Mengambil source code dari Azure DevOps
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
            }
        }

        stage('Navigate to poc folder') {
            steps {
                // Berpindah ke folder poc
                dir('poc') {
                    echo 'Navigating to poc folder...'
                }
            }
        }

        stage('Install npm Dependencies') {
            steps {
                // Menginstal dependencies Node.js dalam folder poc
                dir('poc') {
                    // Cek apakah npm terinstal
                    sh 'npm --version'
                    // Menginstal dependencies
                    sh 'npm install'
                }
            }
        }

        stage('Build Docker Image and Push to Docker Hub') {
            steps {
                script {
                    // Build dan Push Docker image
                    sh '''
                    docker build -t $(imageRepository):$(tag) -f poc/Dockerfile .
                    docker push $(imageRepository):$(tag)
                    '''
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    // Jalankan Docker container pada port 3001
                    sh '''
                    docker run -d -p 3001:3001 --name $(containerName) $(imageRepository):$(tag)
                    '''
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
