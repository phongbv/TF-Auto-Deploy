1.	Update file Auto_build.ps1
•	$localPath: Đường dẫn đến folder chứa file solution(1 workspace chỉ được map đúng 1 branch).
•	$teamCollectionPath: Đường dẫn web đến team collection.
•	$webProfile: Đường dẫn tương đối từ $localPath đến file profile deployment.
•	$solutionPath: Đường dẫn tương đối từ $localPath đến file solution.
2.	Tạo shortcut để chạy lệnh deploy
Tạo shortcut với location: cmd /c C:\RUN_DEPLOY.BAT "C:\Users\StupidBoy\source\repos\TF-Auto-Deploy\TF-Auto-Deploy\TF-Auto-Deploy\bin\Debug". 
Trong đó:
•	C:\Users\StupidBoy\source\repos\TF-Auto-Deploy\TF-Auto-Deploy\TF-Auto-Deploy\bin\Debug là đường dẫn đến folder chứa file auto_build.ps1
•	Đường dẫn đến file RUN_DEPLOY.BAT là đường dẫn tuyệt đối.
3.	Chạy file shorcut để deploy
4.	Nén file đã được deploy theo path được config trong profile deployment.
5.	Giải nén nên folder cần deploy đến.
