﻿Function Find-MsBuild([int] $MaxVersion = 2019)
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
$msbuildPath = Find-MsBuild
#echo $msbuildPath

$localPath = "C:\LOS_DEV"
$webProfile = "$localPath\LOS.Website\Properties\PublishProfiles\LOS-Dev.pubxml"
$solutionPath = "$localPath\LOS.Full.sln"

#$deployCmd = """$msbuildPath""" +' "' + $solutionPath +'" /p:DeployOnBuild=true /p:PublishProfile="' + $webProfile +'"'
$deployCmd = '&"' + $msbuildPath +'" "' + $solutionPath +'" /t:Clean /t:Rebuild /p:DeployOnBuild=true /p:PublishProfile="' + $webProfile +'"'
#echo $deployCmd
$scriptCmd = [ScriptBlock]::Create($deployCmd)
#Get latest source
.\TF-Auto-Deploy.exe $localPath "http://sptserver.ists.com.vn:8080/tfs/iLendingPro"
#Deploy

Invoke-Command -ScriptBlock $scriptCmd

