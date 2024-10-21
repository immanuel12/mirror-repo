pipeline {
    agent any

    stages {
        stage('Clone Repository') {
            steps {
                echo 'Cloning the repository...'
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
                echo 'Repository cloned successfully.'
            }
        }

        stage('Check Node and npm Version') {
            steps {
                echo 'Checking Node.js and npm versions...'
                sh 'node --version'
                sh 'npm --version'
            }
        }

        stage('Navigate to poc folder') {
            steps {
                echo 'Navigating to poc folder...'
                dir('poc') {
                    // Pastikan folder poc ada di dalam repositori
                    echo 'Inside poc folder.'
                }
            }
        }

        stage('Install npm Dependencies') {
            steps {
                dir('poc') {
                    echo 'Installing npm dependencies...'
                    // Menginstal dependencies Node.js dalam folder poc
                    sh 'npm install'
                }
            }
        }
    }

    post {
        success {
            echo 'NPM installation completed successfully!'
        }
        failure {
            echo 'NPM installation failed!'
        }
    }
}
