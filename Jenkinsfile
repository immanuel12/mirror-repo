pipeline {
    agent any

    environment {
        dockerRegistryServiceConnection = 'devops-poc'  // Docker Hub service connection
        imageRepository = 'nuek21/testing-node'  // Nama repository Docker Hub
        tag = "${BUILD_ID}"  // Menggunakan BUILD_ID sebagai tag versi image
        containerName = 'node-app-container'  // Nama container
        npmServiceConnection = 'npmconn'  // Koneksi NPM
    }

    triggers {
        pollSCM('H/5 * * * *')  // Trigger otomatis untuk memeriksa perubahan setiap 5 menit
    }

    stages {
        stage('Checkout Repository') {
            steps {
                // Langkah 1: Checkout repository dari Azure DevOps
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
            }
        }

        stage('Install Node.js') {
            steps {
                // Langkah 2: Install Node.js versi 18
                tool name: 'NodeJS', type: 'NodeJS'
                sh 'node --version'
            }
        }

        stage('Authenticate NPM') {
            steps {
                // Autentikasi ke NPM menggunakan koneksi yang disediakan
                sh '''
                echo '//registry.npmjs.org/:_authToken=${npmServiceConnection}' > poc/.npmrc
                '''
            }
        }

        // Langkah 3: Publish ke NPM dihapus sesuai permintaan
        // Kamu bisa menambahkan langkah lain sesuai kebutuhan di sini

        stage('Build Docker Image and Push to Docker Hub') {
            steps {
                script {
                    // Langkah 4: Build Docker image dan push ke Docker Hub
                    sh '''
                    docker build -t ${imageRepository}:${tag} -f poc/Dockerfile .
                    docker tag ${imageRepository}:${tag} ${imageRepository}:latest
                    docker login -u ${dockerRegistryServiceConnection} -p ${DOCKERHUB_PASSWORD}
                    docker push ${imageRepository}:${tag}
                    docker push ${imageRepository}:latest
                    '''
                }
            }
        }

        stage('Run Docker Container on Port 3001') {
            steps {
                script {
                    // Langkah 5: Jalankan Docker container dengan port 3001
                    sh '''
                    docker run -d -p 3001:3001 --name ${containerName} ${imageRepository}:${tag}
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
