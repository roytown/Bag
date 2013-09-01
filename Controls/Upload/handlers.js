function fileQueueError(file, errorCode, message) {
	try {
	   
		var errorName = "";
		if (errorCode === SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED) {
			errorName = "超出了文件上传个数.";
		}

		if (errorName !== "") {
			alert(errorName);
			return;
		}

		switch (errorCode) {
		case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
		    errorName = "当前文件为0字节";
			break;
		case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
		    errorName ="超出了大小限制";
			break;
		case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
		    errorName="文件类型不符合要求";
		        break;
		}
		alert(message);
		
	} catch (ex) {
		this.debug(ex);
	}

}

function fileDialogComplete(numFilesSelected, numFilesQueued) {
	try {
		if (numFilesQueued > 0) {
			this.startUpload();
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadProgress(file, bytesLoaded) {

	try {
		var percent = Math.ceil((bytesLoaded / file.size) * 100);

		var progress = new FileProgress(file,  this.customSettings.upload_target);
		progress.setProgress(percent);
		if (percent === 100) {
			progress.setStatus("处理中...");
			progress.toggleCancel(false, this);
		} else {
			progress.setStatus("文件上传中...");
			progress.toggleCancel(true, this);
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadSuccess(file, serverData) {
    
	try {
		var progress = new FileProgress(file,  this.customSettings.upload_target);
		if (serverData.substring(0, 1) === "{") {
		    var json = eval('(' + serverData + ')');
		    var di = json.filename.lastIndexOf('.');
		    var ext = json.filename.substring(di + 1).toLowerCase();
		    if (ext == "jpg")
		        ext = "jpeg";
		    else if (ext == "ppt")
		        ext = "pptx";
		    else if (ext == "xls")
		        ext = "xlsx";
		    else if (ext == "doc")
		        ext = "docx";

		    addImage(SWFUPLOAD_ICON[ext + 'icon'], this.customSettings.thumbnail_target, json.filename, json.dir, SWFUPLOAD_ICON["deleteimg"], this.customSettings.deleteurl, this.customSettings.id);

		    progress.setStatus("处理完成.");
		    progress.toggleCancel(false);

		} else {
		    addImage(this.customSettings.defaultimg.error, this.customSettings.thumbnail_target);
		    progress.setStatus("错误.");
		    progress.toggleCancel(false);
		    alert(serverData);

		}

	} catch (ex) {
		this.debug(ex);
	}
}

function uploadComplete(file) {
	try {
		if (this.getStats().files_queued > 0) {
			this.startUpload();
		} else {
			var progress = new FileProgress(file,  this.customSettings.upload_target);
			progress.setComplete();
			progress.setStatus("所有文件上传成功.");
			progress.toggleCancel(false);
		}
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadError(file, errorCode, message) {
    var imageName =  this.customSettings.defaultimg.error;
	var progress;
	try {
		switch (errorCode) {
		case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
			try {
				progress = new FileProgress(file,  this.customSettings.upload_target);
				progress.setCancelled();
				progress.setStatus("取消");
				progress.toggleCancel(false);
			}
			catch (ex1) {
				this.debug(ex1);
			}
			break;
		case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
			try {
				progress = new FileProgress(file,  this.customSettings.upload_target);
				progress.setCancelled();
				progress.setStatus("停止");
				progress.toggleCancel(true);
			}
			catch (ex2) {
				this.debug(ex2);
			}
		case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
		    imageName = this.customSettings.defaultimg.uploadlimit;
			break;
		default:
			alert(message);
			break;
		}

		addImage(imageName, this.customSettings.thumbnail_target);

	} catch (ex3) {
		this.debug(ex3);
	}

}

function deleteimg(obj,deleteurl,hid)
{
    var url = obj.attr("url");
    var delimgobj = obj;
    $.get(deleteurl, { action: 'deleteimg', dir: url }, function (data) {
        if (data != null) {
            var f = false;
            var json = eval('(' + data + ')');
            if (json.result == "ok") {

                var urlarray = $("#" + hid).val().split('|');

                for (var i = 0; i < urlarray.length; ++i) {
                    if (urlarray[i] == url) {
                        urlarray.splice(i, 1);
                        f = true;
                        break;
                    }
                }
                if (f) {
                    var c = delimgobj.parent();
                    c.remove();
                    $("#" + hid).val(urlarray.join('|'));
                }
            }
            else {
                alert(json.msg);
            }

        }
        else {
            alert("删除失败");
        }
    });
}

function addImage(src, container,filename,url,delsrc,deleteurl,hid) {
    var itemc = $("<div></div>");
    itemc.css("float", "left");
    itemc.css("margin", "5px");
    itemc.css("height", "130px");
    itemc.css("overflow", "hidden");
    itemc.css("width", "80px");
    itemc.css("position", "relative");
    $("#" + container).append(itemc);

    var delimg = $("<img/>");
    delimg.css("position", "absolute");
    delimg.css("top", "0px");
    delimg.css("right", "0px");
    delimg.css("width", "16px");
    delimg.attr("src", delsrc);
    delimg.attr("url", url);
    delimg.css("cursor", "pointer");
    if (deleteurl != null) {
        delimg.bind("click", function () {
            deleteimg($(this), deleteurl, hid);
        });
    }
    itemc.append(delimg);

    var newimg = $("<img/>");
    itemc.append(newimg);
   
    newimg.css("width","80px");
   
    if (filename!=null)
    {
        newimg.attr("alt", filename);
        var textc = $("<span></span>");
        textc.css("width", "80px");
        textc.css("overflow", "hidden");
        textc.css("height","25px");
        textc.css("line-height","25px");
        textc.css("float","left");
        textc.css("text-align","center");
        textc.html(filename);
        itemc.append(textc);
    }

    newimg.attr("src", src);

    var h = $("#" + hid);
    var v = h.val();
    h.val(v + "|" + url);
    
}

function FileProgress(file, targetID) {
	this.fileProgressID = "divFileProgress";

	this.fileProgressWrapper = document.getElementById(this.fileProgressID);
	if (!this.fileProgressWrapper) {
		this.fileProgressWrapper = document.createElement("div");
		this.fileProgressWrapper.className = "progressWrapper";
		this.fileProgressWrapper.id = this.fileProgressID;

		this.fileProgressElement = document.createElement("div");
		this.fileProgressElement.className = "progressContainer";

		var progressCancel = document.createElement("a");
		progressCancel.className = "progressCancel";
		progressCancel.href = "#";
		progressCancel.style.visibility = "hidden";
		progressCancel.appendChild(document.createTextNode(" "));

		var progressText = document.createElement("div");
		progressText.className = "progressName";
		progressText.appendChild(document.createTextNode(file.name));

		var progressBar = document.createElement("div");
		progressBar.className = "progressBarInProgress";

		var progressStatus = document.createElement("div");
		progressStatus.className = "progressBarStatus";
		progressStatus.innerHTML = "&nbsp;";

		this.fileProgressElement.appendChild(progressCancel);
		this.fileProgressElement.appendChild(progressText);
		this.fileProgressElement.appendChild(progressStatus);
		this.fileProgressElement.appendChild(progressBar);

		this.fileProgressWrapper.appendChild(this.fileProgressElement);

		document.getElementById(targetID).appendChild(this.fileProgressWrapper);
		fadeIn(this.fileProgressWrapper, 0);

	} else {
		this.fileProgressElement = this.fileProgressWrapper.firstChild;
		this.fileProgressElement.childNodes[1].firstChild.nodeValue = file.name;
	}

	this.height = this.fileProgressWrapper.offsetHeight;

}
FileProgress.prototype.setProgress = function (percentage) {
	this.fileProgressElement.className = "progressContainer green";
	this.fileProgressElement.childNodes[3].className = "progressBarInProgress";
	this.fileProgressElement.childNodes[3].style.width = percentage + "%";
};
FileProgress.prototype.setComplete = function () {
	this.fileProgressElement.className = "progressContainer blue";
	this.fileProgressElement.childNodes[3].className = "progressBarComplete";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setError = function () {
	this.fileProgressElement.className = "progressContainer red";
	this.fileProgressElement.childNodes[3].className = "progressBarError";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setCancelled = function () {
	this.fileProgressElement.className = "progressContainer";
	this.fileProgressElement.childNodes[3].className = "progressBarError";
	this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setStatus = function (status) {
	this.fileProgressElement.childNodes[2].innerHTML = status;
};

FileProgress.prototype.toggleCancel = function (show, swfuploadInstance) {
	this.fileProgressElement.childNodes[0].style.visibility = show ? "visible" : "hidden";
	if (swfuploadInstance) {
		var fileID = this.fileProgressID;
		this.fileProgressElement.childNodes[0].onclick = function () {
			swfuploadInstance.cancelUpload(fileID);
			return false;
		};
	}
};
