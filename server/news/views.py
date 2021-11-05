from rest_framework.response import Response
from rest_framework.views import APIView

from review.models import Review
from .models import News
from .serialaizers import NewsListSerializers, ReviewCreateSerializers

# Create your views here.

class NewsListView(APIView):
    """Вывод списка новостей"""

    def get(self, request):
        news = News.objects.all()
        serializer = NewsListSerializers(news, many=True)

        return Response(serializer.data)


class ReviewCreateView(APIView):
    '''Добавление комментариев'''
    def post(self, request):
        review = ReviewCreateSerializers(data=request.data)
        if review.is_valid():
            review.save()
        return Response(status=201)