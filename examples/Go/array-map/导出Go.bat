echo off

set currentDir=%cd%
cd ..\..\
set rootDir=%cd%
cd %currentDir%
set PYTHONPATH=%rootDir%

set taxi_alias=python %rootDir%\taxi\cli.py
set importArgs="file=%currentDir%\��������.xlsx"
set exportArgs="pkg=config,outdata-dir=%currentDir%\proj,out-src-file=%currentDir%\proj\autogen.go"

%taxi_alias%  --mode=excel --import-args=%importArgs% --generator="go-v1" --export-args=%exportArgs%

pause
REM array-delim