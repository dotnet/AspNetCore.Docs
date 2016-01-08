/* msc-throttle.js - start */
$.throttle = function (fn, threshhold, scope) {
	threshhold || (threshhold = 250);
	var last,
		deferTimer;
	return function () {
		var context = scope || this;

		var now = +new Date,
			args = arguments;
		if (last && now < last + threshhold) {
			// hold on to it
			clearTimeout(deferTimer);
			deferTimer = setTimeout(function () {
				last = now;
				fn.apply(context, args);
			}, threshhold);
		} else {
			last = now;
			fn.apply(context, args);
		}
	};
}
/* msc-throttle.js - end */

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

				$(window).scroll($.throttle(function ()
				{
					_this.updateFixed();
					_this.show();
					_this.isDone();
				}, 50));
			},

			initLoad: function ()
			{
				if (this.getStorage(this.targetKeyId) === null)
				{
					this.shouldShow = true;
					this.updateFixed();
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

			isDone: function ()
			{
				if (this.completed && this.$container.is(":visible"))
				{
					this.$container.slideUp('fast');
				}
			},

			updateFixed: function ()
			{
				if (options.alwaysFixed)
				{
					return;
				}

				if (!this.closed && !this.completed)
				{
					var updateFixedTop = this.$positionContainer.offset().top;

					if (($(window).scrollTop() + $(window).height() - this.$container.outerHeight(true)) > updateFixedTop)
					{
						this.$container.removeClass("fixed");
					}
					else
					{
						this.$container.addClass("fixed");
					}
				}
			},

			show: function ()
			{
				if (!this.closed && !this.completed && this.shouldShow && !this.$container.is(":visible"))
				{
					var documentHeight = $(document).height();
					var windowHeight = $(window).height();
					var enoughScrollbars = (documentHeight - windowHeight) > 200;

					if ($(window).scrollTop() > 100 || !enoughScrollbars)
					{
						this.$container.slideDown('fast');
					}
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
								this.showMessage(".error");
							}
						},
						error: function ()
						{
							this.showMessage(".error");
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
								this.showMessage(".error");
							}
						},
						error: function ()
						{
							this.showMessage(".error");
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
	$("#helpful").appendTo("body");	
});
/* msc-helpfulness.js overrides - end */
