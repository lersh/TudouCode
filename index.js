'use strict'
const spawn = require('child_process').spawn;

var free = spawn('dotnet', ['./TudouSharp/bin/release/netcoreapp2.0/TudouSharp.dll']);

free.stdout.on('data', function (data) {
    console.log('standard output:\n' + data);
});
