pipeline {
    agent any

    stages {
        stage('Checkout from Azure DevOps') {
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

        stage('Install Dependencies') {
            steps {
                // Menginstall dependencies Node.js dalam folder poc
                dir('poc') {
                    sh 'npm install'
                }
            }
        }

        stage('Run Tests') {
            steps {
                // Menjalankan unit tests dalam folder poc
                dir('poc') {
                    sh 'npm test'
                }
            }
        }

        stage('Build and Run') {
            steps {
                // Menjalankan aplikasi Node.js dalam folder poc
                dir('poc') {
                    sh 'npm start'
                }
            }
        }

        stage('Run pipeline.yml') {
            steps {
                // Menjalankan file pipeline.yml dalam folder poc
                dir('poc') {
                    // Sesuaikan perintah ini dengan cara Anda ingin menjalankan pipeline.yml
                    sh 'pipeline.yml'  // Misalnya, jika menggunakan make, curl, atau perintah lainnya
                }
            }
        }
    }

    post {
        success {
            echo 'Build and test completed successfully!'
        }
        failure {
            echo 'Build or tests failed!'
        }
    }
}
