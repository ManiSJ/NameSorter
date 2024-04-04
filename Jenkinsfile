pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                // Print the system username of the user who is running Jenkins
                  script {
                      def sysUsername = bat(script: 'echo %USERNAME%', returnStdout: true).trim()
                      echo "System username: ${sysUsername}"
                  }
                
                // Clean and build the console app
                bat 'dotnet clean NameSorter.sln'
                bat 'dotnet build NameSorter.sln'
            }
        }
        stage('Test') {
            steps {
                // Run tests
                bat 'dotnet test NameSorter.sln'
            }
        }
        stage('Publish') {
            steps {
                // Publish the console app to the C:\Users\username\AppData\Local\YourConsoleApp folder
                script {
                    def sysUsername = bat(script: 'echo %USERNAME%', returnStdout: true).trim()
                    bat "dotnet publish NameSorter.sln -c Release -o C:\\Users\\${sysUsername}\\AppData\\Local\\NameSorter"
                }
            }
        }
        stage('Run Console App') {
            steps {
                // Run the console app with arguments from the published folder
                script {
                    def sysUsername = bat(script: 'echo %USERNAME%', returnStdout: true).trim()
                    bat 'C:\\Users\\${sysUsername}\\AppData\\Local\\NameSorter\\NameSorter.exe unsorted-names-list.txt'
                }
            }
        }
    }
    post {
        success {
            // Perform actions if the build succeeds
            echo 'Build successful'
            // For example, you can archive artifacts
            script {
                def sysUsername = bat(script: 'echo %USERNAME%', returnStdout: true).trim()
                // Archive artifacts using the system username in the path
                archiveArtifacts artifacts: "C:/Users/${sysUsername}/AppData/Local/NameSorter/**"
            }
        }
        failure {
            // Perform actions if the build fails
            echo 'Build failed'
        }
    }
}
