from django.contrib.auth.base_user import AbstractBaseUser, BaseUserManager
from django.contrib.auth.models import PermissionsMixin
from django.db import models


from review.models import Review
from news.models import News
# Create your models here.

class UserModel(AbstractBaseUser):
    pass



class UserProfil(models.Model):
    user = models.OneToOneField(UserModel, models.CASCADE)
    review = models.ForeignKey(Review, on_delete=models.CASCADE, related_name="UserReview")
    news = models.ForeignKey(News, on_delete=models.CASCADE, related_name="UserNews")


class UserFollowing(models.Model):
    user_id = models.ForeignKey(UserProfil, on_delete=models.CASCADE, related_name="following")
    following_user_id = models.ForeignKey(UserProfil, on_delete=models.CASCADE, related_name="followers")
    created = models.DateTimeField(auto_now_add=True)