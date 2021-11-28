from django.contrib import admin
from news.models import News
from review.models import Review
from profileUser.models import UserProfil
# Register your models here.


admin.site.register(News)
admin.site.register(Review)
admin.site.register(UserProfil)