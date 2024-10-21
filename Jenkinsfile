pipeline {
    agent any

    tools {
        nodejs 'NodeJS' // Sesuaikan dengan nama yang Anda berikan pada konfigurasi
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
                // Menginstall dependencies Node.js dalam folder poc
                dir('poc') {
                    // Cek apakah npm terinstal
                    sh 'npm --version'
                    // Menginstal dependencies
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
