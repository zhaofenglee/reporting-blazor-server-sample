# 生成版本号
#$version = Get-Date -Format "yyyyMMddHHmm"
$version = "latest"

# 执行 dotnet publish
dotnet publish -c Release

# 执行 docker build
docker build -f Dockerfile.local -t "acme.bookstore.report.blazor.server:$version" .

# 执行 docker push
#docker push "acme.bookstore.report.blazor.server:$version"

"发布成功，版本号 $version "
Pause