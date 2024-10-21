pipeline {
    agent any

    tools {
        nodejs 'NodeJS' // Sesuaikan dengan nama NodeJS yang sudah diinstal di Jenkins
    }

    environment {
        DOCKER_CREDENTIALS_ID = 'devops-poc' // Nama service connection ke Docker
        IMAGE_REPOSITORY = 'nuek21/testing-node'
        TAG = "${env.BUILD_ID}"
        CONTAINER_NAME = 'node-app-container'
        NPM_SERVICE_CONNECTION = 'npmconn' // Nama service connection ke npm registry
    }

    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
            }
        }

        stage('Navigate to poc folder') {
            steps {
                dir('poc') {
                    echo 'Navigating to poc folder...'
                }
            }
        }

        stage('Install npm Dependencies') {
            steps {
                dir('poc') {
                    // Cek apakah npm terinstal dan install dependensi
                    sh 'npm --version'
                    sh 'npm install'
                }
            }
        }

        stage('Authenticate to npm') {
            steps {
                dir('poc') {
                    // Set registry untuk npm
                    sh 'npm config set registry https://registry.npmjs.org/'
                }
            }
        }

        stage('Publish to npm') {
            steps {
                dir('poc') {
                    // Membersihkan cache npm untuk menghindari masalah cache
                    sh 'npm cache clean --force'
                    // Mencoba untuk publish package
                    sh 'npm publish'
                }
            }
        }

        stage('Build and Push Docker Image') {
            steps {
                script {
                    docker.withRegistry('https://index.docker.io/v1/', "${env.DOCKER_CREDENTIALS_ID}") {
                        def app = docker.build("${env.IMAGE_REPOSITORY}:${env.TAG}", '-f poc/Dockerfile .')
                        app.push("${env.TAG}")
                        app.push('latest')
                    }
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    sh "docker run -d -p 3001:3001 --name ${env.CONTAINER_NAME} ${env.IMAGE_REPOSITORY}:${env.TAG}"
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
