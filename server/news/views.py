from rest_framework.response import Response
from rest_framework.views import APIView

from .models import News
from .serialaizers import NewsListSerializers

# Create your views here.

class NewsListView(APIView):
    """Вывод списка новостей"""

    def get(self, request):
        news = News.objects.all()
        serializer = NewsListSerializers(news, many=True)

        return Response(serializer.data)
