var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var request = require('request');
var routes = require('./routes/index');
var users = require('./routes/users');
var urlModule = require('url');
var app = express();

// view engine setup
//app.set('views', path.join(__dirname, 'views'));
//app.set('view engine', 'jade');

// uncomment after placing your favicon in /public
//app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(require('stylus').middleware(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', users);

app.get('/getData', function (req, res) {
    
    var typeValue = req.query.type;
    var urlValue = req.query.url;
     
    var resultsFromFunction;
    request(urlValue, function (error, response, html) {
        
        if (!error && response.statusCode === 200) {
            if (typeValue.toString().match('channellist')) {
                resultsFromFunction = users.channelList(html);
            }
            else if (typeValue.toString().match('dramalist')) {
                resultsFromFunction = users.dramaList(html);
            }
            else if (typeValue.toString().match('epilist')) {
                resultsFromFunction = users.epiList(html);
            }
            else if (typeValue.toString().match('epilink')) {
                resultsFromFunction = users.epiLink(html);
            }
            
            
            res.end(JSON.stringify(resultsFromFunction));

        }
        else {
            console.log('\nShowing error...\n');
            console.log(error);
        }
            
    });
   
});


// catch 404 and forward to error handler
app.use(function (req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use(function (err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// production error handler
// no stacktraces leaked to user
app.use(function (err, req, res, next) {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});
module.exports = app;
