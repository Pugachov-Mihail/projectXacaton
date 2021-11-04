from rest_framework import serializers

from .models import News


class NewsListSerializers(serializers.ModelSerializer):
    '''Список новостей '''

    class Meta:
        model = News
        fields = ('id', 'autor', 'news', 'text', 'date')