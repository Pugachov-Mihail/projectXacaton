from django.contrib import admin
from news.models import News
from review.models import Review
# Register your models here.


admin.site.register(Review)
admin.site.register(News)