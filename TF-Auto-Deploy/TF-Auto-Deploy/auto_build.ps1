$localPath = "C:\LOS_DEV"
$webProfile = "$localPath\LOS.Website\Properties\PublishProfiles\LOS-Dev.pubxml"
$solutionPath = "$localPath\LOS.Full.sln"

$deployCmd = 'msbuild "' + $solutionPath +'" /p:DeployOnBuild=true /p:PublishProfile="' + $webProfile +'"'
echo $deployCmd
$scriptCmd = [ScriptBlock]::Create($deployCmd)

echo $webProfile
#Get latest source
#.\TF-Auto-Deploy.exe $localPath "http://sptserver.ists.com.vn:8080/tfs/iLendingPro"
#Deploy

Invoke-Command -ScriptBlock $scriptCmd