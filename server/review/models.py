from django.db import models

from news.models import News

# Create your models here.


class Review(models.Model):
    name = models.CharField(max_length=50)
    date = models.DateField(auto_now_add=True)
    review = models.TextField(max_length=300)
    news = models.ForeignKey(News, on_delete=models.CASCADE, related_name="review")
