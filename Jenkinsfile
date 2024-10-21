pipeline {
    agent any

    tools {
        nodejs "NodeJS" // Sesuaikan dengan nama yang Anda berikan pada konfigurasi
    }

    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main',
                    url: 'https://ImmanuelSianturi@dev.azure.com/ImmanuelSianturi/Project-Poc/_git/Project-Poc'
            }
        }

        stage('Install npm Dependencies') {
            steps {
                sh 'npm install' // Menginstall dependencies Node.js
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
