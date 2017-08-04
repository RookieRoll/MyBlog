FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
Env MYSQL "139.199.165.121"
ENV MYUSERNSME "root"
ENV PASSWORD "123456"
ENTRYPOINT ["dotnet", "MyBlog.AdminBlog.dll"]
