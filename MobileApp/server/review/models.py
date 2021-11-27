from django.db import models
from django.contrib.auth.models import User

from news.models import News

# Create your models here.


class Review(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    date = models.DateField(auto_now_add=True)
    review = models.TextField(max_length=300)
    news = models.ForeignKey(News, on_delete=models.CASCADE, related_name="review")
