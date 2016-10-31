/* msc-helpfulness.js - start */
;(function ($)
{
	$.Helpfulness = function (options)
	{
		var documentId = $("[data-documentid]").attr("data-documentid");
		var docId = typeof (READTHEDOCS_DATA) !== 'undefined' ? READTHEDOCS_DATA.docroot + READTHEDOCS_DATA.page : options.domain !== "" ? window.location.href : "";

		return {
			targetDocumentId: documentId,
			targetPickerId: $("[data-pickerid]").attr("data-pickerid"),
			targetDocId: docId,
			targetKeyId: documentId || docId || 0,
			$container: $(".helpfulness-container"),
			$content: $(".helpfulness"),
			$positionContainer: $("#helpful-position"),
			shouldShow: false,
			closed: false,
			completed: false,

			init: function ()
			{
				if (this.$container == null)
				{
					return;
				}
				
				this.initHandlers();
				this.initLoad();
			},

			initHandlers: function ()
			{
				var _this = this;

				$("#helpfulness-btn-yes").click(function ()
				{
					_this.submitYes();
				});

				$("#helpfulness-btn-no").click(function ()
				{
					$(".helpfulness-form").hide();
					$(".helpfulness-form-no").show();
				});

				$("#txt-helpfulness").attr("maxlength", options.maxCharacters);
				$("#helpfulness-characters-left").prepend(options.maxCharacters + " ");

				$("#txt-helpfulness").on('input propertychange paste', function ()
				{
					var left = options.maxCharacters - $(this).val().length;
					if (left < 0)
					{
						left = 0;
					}
					$("#helpfulness-characters-left").text(left + " character" + (left === 1 ? "" : "s") + " remaining");
				});

				$("#helpfulness-btn-submit").click(function ()
				{
					var reason = $("#txt-helpfulness").val().substring(0, options.maxCharacters);
					_this.submitNo(reason);
				});

				$("#helpfulness-btn-skip").click(function ()
				{
					_this.submitNo("");
				});

				$(".helpfulness-close").click(function ()
				{
					_this.closed = true;
					$("#helpful").slideUp('fast');
				});
				
				$(document).keyup(function (e)
				{
					if (e.keyCode === 27)
					{
						_this.closed = true;
						$("#helpful").slideUp('fast');
					}
				});
			},

			initLoad: function ()
			{
				if (this.getStorage(this.targetKeyId) === null)
				{
					this.shouldShow = true;
					this.show();					
				}

				$.ajax({
					context: this,
					url: options.domain + "/umbraco/api/helpfulnessapi/reportsummarybyid",
					type: "POST",
					data: {
						contentId: this.targetDocumentId,
						docId: this.targetDocId
					},
					success: function (data)
					{
						if (data !== null && data !== "")
						{
							if (options.isDocs && $("#helpfulness-data").length === 0)
							{
								$("h1").after("<div id='helpfulness-data' class='helpful-text'>" + data + "</div>");
							}
							else
							{
								$("#helpfulness-data").text(data).css("visibility", "visible");
							}
						}
					}
				});
			},

			show: function ()
			{
				if (!this.closed && !this.completed && this.shouldShow && !this.$container.is(":visible"))
				{
					this.$container.show();
				}
			},

			submitYes: function()
			{
				if (this.targetKeyId)
				{
					$(".helpfulness-form").hide();
					this.showMessage(".processing");

					$.ajax({
						context: this,
						url: options.domain + "/umbraco/api/helpfulnessapi/submityes",
						type: "POST",
						data: {
							pickerId: this.targetPickerId,
							contentId: this.targetDocumentId,
							docId: this.targetDocId
						},
						success: function (data)
						{
							if (data !== null && data === "success")
							{
								this.showMessage(".success");

								this.setStorage(this.targetKeyId);
								this.completed = true;

								this.initLoad();
							}
							else
							{
								this.showMessage(".helpfulness-error");
							}
						},
						error: function ()
						{
							this.showMessage(".helpfulness-error");
						}
					});
				}
			},

			submitNo: function (value)
			{
				if (this.targetKeyId)
				{
					$(".helpfulness-form-no").hide();
					this.showMessage(".processing");

					$.ajax({
						context: this,
						url: options.domain + "/umbraco/api/helpfulnessapi/submitno",
						type: "POST",
						data: {
							pickerId: this.targetPickerId,
							contentId: this.targetDocumentId,
							docId: this.targetDocId,
							reason: value
						},
						success: function (data)
						{
							if (data !== null && data === "success")
							{
								this.showMessage(".success");

								this.setStorage(this.targetKeyId);
								this.completed = true;

								this.initLoad();
							}
							else
							{
								this.showMessage(".helpfulness-error");
							}
						},
						error: function ()
						{
							this.showMessage(".helpfulness-error");
						}
					});
				}
			},

			getStorage: function (contentId)
			{
				if (window.localStorage)
				{
					return localStorage.getItem("helpfulness-" + contentId);
				}

				return null;
			},

			setStorage: function (contentId)
			{
				if (window.localStorage)
				{
					try
					{
						localStorage.setItem("helpfulness-" + contentId, 1);
						return true;
					}
					catch (e)
					{
						return false;
					}
				}

				return false;
			},

			showMessage: function (message)
			{
				this.$content.children(".messages").hide();
				this.$content.children(message).show();
			}
		};
	};
})(jQuery);

$(function ()
{
	$.Helpfulness({
		maxCharacters: 1000,
		alwaysFixed: true,
		domain: "https://www.asp.net",
		isDocs: true
	}).init();
});
/* msc-helpfulness.js - end */

/* msc-helpfulness.js overrides - start */
$(function ()
{	
	$("#helpful").insertBefore("footer hr");	
});
/* msc-helpfulness.js overrides - end */
