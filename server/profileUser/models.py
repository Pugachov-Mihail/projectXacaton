from django.db import models
from django.contrib.auth.models import User
from django.db.models.signals import post_save
from django.dispatch import receiver

from review.models import Review
from news.models import News
# Create your models here.

class UserProfil(models.Model):
    user = models.OneToOneField(User, models.CASCADE)
    review = models.ForeignKey(Review, on_delete=models.CASCADE, related_name="UserReview")
    news = models.ForeignKey(News, on_delete=models.CASCADE, related_name="UserNews")

    @receiver(post_save, sender=User)
    def create_user_profile(sender, instance, created, **kwargs):
        if created:
            UserProfil.objects.create(user=instance)

    @receiver(post_save, sender=User)
    def save_user_profile(sender, instance, **kwargs):
        instance.profile.save()



class UserFollowing(models.Model):
    user_id = models.ForeignKey(UserProfil, on_delete=models.CASCADE, related_name="following")
    following_user_id = models.ForeignKey(UserProfil, on_delete=models.CASCADE, related_name="followers")
    created = models.DateTimeField(auto_now_add=True)