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
        
        stage('Install Dependencies') {
            steps {
                // Berpindah ke directory 'poc' dan menginstall dependencies Node.js
                dir('poc') {
                    sh 'npm install'
                }
            }
        }

        stage('Run Tests') {
            steps {
                // Berpindah ke directory 'poc' dan menjalankan unit tests
                dir('poc') {
                    sh 'npm test'
                }
            }
        }

        stage('Build and Run') {
            steps {
                // Berpindah ke directory 'poc' dan menjalankan aplikasi Node.js
                dir('poc') {
                    sh 'npm start'
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
