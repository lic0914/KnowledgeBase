由于.Net Core默认只会从wwwroot目录加载静态文件，其他文件夹的静态文件无法正常访问。而我们希望将图片上传到网站根目录的upload文件夹下，
所以需要额外在Startup.cs类的Configure方法中，增加如下代码：

app.UseStaticFiles(new StaticFileOptions
{
   FileProvider = new PhysicalFileProvider(
       Path.Combine(Directory.GetCurrentDirectory(), "upload")),
   RequestPath = "/upload",
   OnPrepareResponse = ctx =>
   {
       ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
   }
});
然后在项目的根目录，创建upload文件夹（这里不创建会报错）。