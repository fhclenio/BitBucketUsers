using BitBucketUsers;

Setup setup = new Setup();
setup.Init();

ApiRequest.RunAsync(setup).Wait();