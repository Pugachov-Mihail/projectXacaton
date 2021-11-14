from django.db import models


# Create your models here.


class News(models.Model):
    title = models.CharField(max_length=150)
    autor = models.CharField(max_length=50)
    news = models.SlugField(max_length=50, blank=True ,null=True)
    text = models.TextField(max_length=500)
    date = models.DateField(auto_now_add=True)
    publication = models.BooleanField(default=False)



