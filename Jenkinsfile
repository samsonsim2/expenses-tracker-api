pipeline {
    agent any
    stages {
      
       stage('Checkout') {
            steps {
                git branch: 'master', url: 'https://github.com/samsonsim2/expenses-tracker-api.git'
            }
        }

        stage('Install tools') {
            steps {
                // Install .NET SDK version required by your project
                sh 'curl -sSL https://raw.githubusercontent.com/dotnet/scripting/master/install-sdk.sh | bash -s -- -version 6.0'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Publish artifacts') {
            steps {
                publish artifacts('bin/Release/*.dll')
            }
        }
}
