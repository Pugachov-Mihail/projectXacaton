from django.db import models
from django.contrib.auth.models import User

# Create your models here.


class News(models.Model):
    title = models.CharField(max_length=150)
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='user')
    news = models.SlugField(max_length=50, blank=True, null=True)
    text = models.TextField(max_length=500)
    date = models.DateField(auto_now_add=True)
    publication = models.BooleanField(default=False)



