pipeline {
    agent any
    
    environment {
        POWER_SCRIPT = '''
            $username = (Get-WmiObject -Class Win32_ComputerSystem).UserName
            $split = $username -split '\\\\'
            $split[1]
        '''
    }
    
    stages {
        stage('Build') {
            steps {
                // Clean and build solution
                bat 'dotnet clean NameSorter.sln'
                bat 'dotnet build NameSorter.sln'
            }
        }
        stage('Test') {
            steps {
                // Run test project on solution
                bat 'dotnet test NameSorter.sln'
            }
        }
        stage('Publish') {
            steps {
                // Publish solution
                script {
                    def sysUsername = powershell(returnStdout: true, script: env.POWER_SCRIPT).trim()
                    bat "dotnet publish NameSorter.sln -c Release -o C:\\Users\\${sysUsername}\\AppData\\Local\\NameSorter"
                }
            }
        }
        stage('Run Console App') {
            steps {
                // Run the console app with arguments from the published folder
                script {
                    def sysUsername = powershell(returnStdout: true, script: env.POWER_SCRIPT).trim()
                    dir("C:\\Users\\${sysUsername}\\AppData\\Local\\NameSorter") {
                        // Run the executable
                        bat "NameSorter.exe unsorted-names-list.txt"
                    }
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
                def sysUsername = powershell(returnStdout: true, script: env.POWER_SCRIPT).trim()
                // Archive artifacts using the system username in the path
                archiveArtifacts artifacts: "NameSorter/**"
            }
        }
        failure {
            // Perform actions if the build fails
            echo 'Build failed'
        }
    }
}
