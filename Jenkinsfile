pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Task: Compiling the .NET application and restoring dependencies.'
                echo 'Tool: dotnet build'
                sh 'dotnet build'
            }
        }

        stage('Unit and Integration Tests') {
            steps {
                echo 'Task: Running unit and integration tests for the .NET application.'
                echo 'Tool: dotnet test'
                sh 'dotnet test'
            }
        }

        stage('Code Analysis') {
            steps {
                echo 'Task: Analyzing code quality, maintainability, and detecting code smells.'
                echo 'Tool: SonarQube'
                echo 'Running SonarQube scanner...'
            }
        }

        stage('Security Scan') {
            steps {
                echo 'Task: Scanning for known vulnerabilities in dependencies.'
                echo 'Tool: OWASP Dependency-Check'
                echo 'Running dependency-check...'
            }
        }

        stage('Deploy to Staging') {
            steps {
                echo 'Task: Deploying the application to a staging environment.'
                echo 'Tool: Docker & Kubernetes (or Azure App Service)'
                echo 'Deploying to staging environment...'
            }
        }

        stage('Integration Tests on Staging') {
            steps {
                echo 'Task: Running integration and end-to-end tests on the staging environment.'
                echo 'Tool: Postman or Selenium'
                echo 'Running integration tests on staging...'
            }
        }

        stage('Deploy to Production') {
            steps {
                echo 'Task: Deploying the verified application to production.'
                echo 'Tool: Ansible or Helm'
                echo 'Deploying to production...'
            }
        }
    }
}
