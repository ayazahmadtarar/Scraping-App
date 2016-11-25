var express = require('express');
var request = require('request');
var cheerio = require('cheerio');
var router = express.Router();


//var mainUrl = "http://dramaonline.com/";
var mainUrl = "http://dramaonline.com/geo-tv-latest-dramas-episodes-online/"
//var mainUrl = "http://dramaonline.com/category/diyar-e-dil/"
//var mainUrl = "http://dramaonline.com/ishqa-waay-episode-32-in-hd/"


router.get('/', function (req, res) {
    request(mainUrl, function (error, response, html) {
        if (!error && response.statusCode === 200) {
            // var channelResult = channelList(html);
            var dramaResult = dramaList(html);
            //var epiResut = epiList(html);
            //  var epilink = epiLink(html);
            res.send(dramaResult);
        }
        return console.log(error);
    });
});

var channelList = function (html) {
    var channellist = {};
    
    var i = 0;
    var $ = cheerio.load(html);
    $('ul.channels-list-area>li').each(function (i, element) {
        var data1 = $(this);
        var channelName = data1.children().text();
        var channelImage = data1.children().children().attr("src");
        var channellink = data1.children().attr("href");
        
        list = {
            channelName: channelName,
            
            channelImage: channelImage,
            channellink: channellink,
    
        };
        channellist[i] = list;
        i++;
    })
    
    return channellist;
};
var dramaList = function (html) {
    var daramas = {};
    
    var i = 0;
    var $ = cheerio.load(html);
    
    $('.thecontent>table').filter(function () {
        var daramaList = {};
        var data1 = $(this);
        $('tr>td>a').each(function (i) {
            var data2 = $(this);
            var daramaImage = data2.children().first().attr("src");
            var dramaLink = data2.attr("href");
            dataDrama = {
                daramaImage: daramaImage,
                dramaLink: dramaLink,         
            };
            daramas[i] = dataDrama;
            i++;
        });
    
    })
    return daramas;
};
var epiList = function (html) {
    var epilistJson = {};
    
    var i = 0;
    var $ = cheerio.load(html);
    
    
    $('.latestPost-content').each(function (i, element) {
        var epiArray = $(this);
        var episodeLink = epiArray.children().first().attr("href");
        var episodeName = epiArray.children().first().attr("title");
        var episodeImage = epiArray.children().children().children().first().attr("src");
        episodes = {
            episodelink: episodeLink,            
            episodename: episodeName,  
        };
        epilistJson[i] = episodes;
        i++;
    })
    return epilistJson
};
var epiLink = function (html) {
    var elink = {};
    var i = 0;
    var $ = cheerio.load(html);
    $('.thecontent').each(function (i, element) {
        
        var iframe = $('iframe');
        var play = iframe.attr("src");
        
        video = {
            videolink: play,            
           
        };
        elink = video;
        i++;
    })
    
    return elink;

};

module.exports = router;
module.exports.channelList = channelList;
module.exports.dramaList = dramaList;
module.exports.epiList = epiList;
module.exports.epiLink = epiLink;