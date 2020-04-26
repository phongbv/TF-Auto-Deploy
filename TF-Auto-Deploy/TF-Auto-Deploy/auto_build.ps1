#Load Assembly
Add-Type -Path TF-Auto-Deploy.dll

Function Find-MsBuild([int] $MaxVersion = 2019)
{
    $vs2019Path = "$Env:programfiles (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\msbuild.exe"
    $agentPath = "$Env:programfiles (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\msbuild.exe"
    $devPath = "$Env:programfiles (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe"
    $proPath = "$Env:programfiles (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\msbuild.exe"
    $communityPath = "$Env:programfiles (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe"
    $fallback2015Path = "${Env:ProgramFiles(x86)}\MSBuild\14.0\Bin\MSBuild.exe"
    $fallback2013Path = "${Env:ProgramFiles(x86)}\MSBuild\12.0\Bin\MSBuild.exe"
    $fallbackPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319"

	If ((2019 -le $MaxVersion) -And (Test-Path $vs2019Path)) { return $vs2019Path } 
    If ((2017 -le $MaxVersion) -And (Test-Path $agentPath)) { return $agentPath } 
    If ((2017 -le $MaxVersion) -And (Test-Path $devPath)) { return $devPath } 
    If ((2017 -le $MaxVersion) -And (Test-Path $proPath)) { return $proPath } 
    If ((2017 -le $MaxVersion) -And (Test-Path $communityPath)) { return $communityPath } 
    If ((2015 -le $MaxVersion) -And (Test-Path $fallback2015Path)) { return $fallback2015Path } 
    If ((2013 -le $MaxVersion) -And (Test-Path $fallback2013Path)) { return $fallback2013Path } 
    If (Test-Path $fallbackPath) { return $fallbackPath } 
        
    throw "Yikes - Unable to find msbuild"
}

Function Exe-Command([string] $cmd)
{
	$scriptCmd = [ScriptBlock]::Create($cmd)
	Invoke-Command -ScriptBlock $scriptCmd
}
$latestChangeset = -1;
$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
$msbuildPath = Find-MsBuild
#echo $msbuildPath

$localPath = "E:\LOSRestruct\LOSRestruct2019"
$webProfile = "$localPath\LOS.Website\Properties\PublishProfiles\LOS-Dev.pubxml"
$solutionPath = "$localPath\LOS.Full.sln"
$teamCollectionPath = "http://sptserver.ists.com.vn:8080/tfs/iLendingPro"


#Get latest source
#$latestChangeset = .\TF-Auto-Deploy.exe $localPath $teamCollectionPath 
$sourceParams = $localPath,$teamCollectionPath 
$latestChangeset =[TFS.SourceUtil]::GetLatestSource($sourceParams)
if($latestChangeset -eq -1){
    echo 'Co loi khi xay ra khi get code. Vui long thu lai.';
    return;
}
#Deploy
$deployCmd = '&"' + $msbuildPath +'" "' + $solutionPath +'" /p:DeployOnBuild=true /p:PublishProfile="' + $webProfile +'"'

#Start Clean
$cleanCmd = '&"' + $msbuildPath +'" "' + $solutionPath +'" /t:Clean'
echo "Clean project"

Exe-Command $cleanCmd
$buildCmd = '&"' + $msbuildPath +'" "' + $solutionPath +'" /t:build'
echo "Build"
Exe-Command  $buildCmd
echo "Deploy"
Exe-Command $deployCmd

$stopwatch.Stop();
$totalSecs =  [math]::Round($stopwatch.Elapsed.TotalSeconds,0)
echo ("Da deploy thanh cong changeset: " + $latestChangeset +", tong thoi gian deploy:" + $totalSecs +"s")