echo off

set currentDir=%cd%
cd ..\..\..\
set rootDir=%cd%
cd %currentDir%

set PYTHONPATH=%rootDir%

set taxi_alias=python %rootDir%\taxi\cli.py
set importArgs="file=%currentDir%\ȫ�ֱ�����.xlsx"
set exportArgs="pkg=config, src-encoding=gbk, outdata-dir=%currentDir%\res,out-src-file=%currentDir%\src\AutoGenConfig"

%taxi_alias%  --mode=excel --import-args=%importArgs% --generator="cpp-csv" --output-format=csv --export-args=%exportArgs%

pause