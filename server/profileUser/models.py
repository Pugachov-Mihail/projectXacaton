from django.contrib.auth.base_user import AbstractBaseUser, BaseUserManager
from django.contrib.auth.models import PermissionsMixin
from django.contrib.auth.models import User
from django.db import models


from review.models import Review
from news.models import News
# Create your models here.

class UserManager(BaseUserManager):
    def _create_user(self, email, username, password, **extra_fiels):
        if not email:
            raise ValueError("Не введен email")
        if not username:
            raise ValueError("Не введен логин")
        user = self.model(
            email=self.normalize_email(email),
            username=username,
            **extra_fiels,
        )
        user.set_password(password)
        user.save(using=self._db)
        return user

    def create_user(self, email, password, username):
        return self._create_user(email, username, password)



class UserProfil(models.Model):
    user = models.ForeignKey(User, models.CASCADE)
    review = models.ForeignKey(Review, blank=True, null=True, on_delete=models.CASCADE, related_name="UserReview")
    news = models.ForeignKey(News, on_delete=models.CASCADE, blank=True, null=True, related_name="UserNews")


class UserFollowing(models.Model):
    user_id = models.ForeignKey(User, on_delete=models.CASCADE, related_name="following")
    following_user_id = models.ForeignKey(UserProfil, on_delete=models.CASCADE, related_name="followers")
    created = models.DateTimeField(auto_now_add=True)