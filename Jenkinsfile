pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = 'nuek21/testing-node'
        CONTAINER_NAME = 'node-app-container'
    }

    stages {
        stage('Checkout Code') {
            steps {
                git url: 'https://dev.azure.com/ImmanuelSianturi/_git/Project-Poc', branch: 'main'
            }
        }

        stage('Install Node.js') {
            tools {
                nodejs 'NodeJS_18' // Make sure this is configured in Jenkins
            }
            steps {
                sh 'npm install'
            }
        }

        stage('Publish to npm') {
            steps {
                sh '''
                    cp /path/to/secret/.npmrc ./poc/.npmrc
                    cd poc
                    npm publish
                '''
            }
        }

        stage('Build Docker Image') {
            steps {
                sh '''
                    docker build -t ${DOCKER_REGISTRY}:${BUILD_NUMBER} -f poc/Dockerfile .
                    docker tag ${DOCKER_REGISTRY}:${BUILD_NUMBER} ${DOCKER_REGISTRY}:latest
                    docker push ${DOCKER_REGISTRY}:${BUILD_NUMBER}
                    docker push ${DOCKER_REGISTRY}:latest
                '''
            }
        }

        stage('Run Docker Container') {
            steps {
                sh 'docker run -d -p 3001:3001 --name ${CONTAINER_NAME} ${DOCKER_REGISTRY}:${BUILD_NUMBER}'
            }
        }
    }
}
