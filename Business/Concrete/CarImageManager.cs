using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Insert(IFormFile formFile, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var imagePathResult = FileUpload.Add(formFile);
            if (!imagePathResult.Success)
                return imagePathResult;

            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now;

            _carImageDal.Insert(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.Id);
            if (!result.Success)
                return result;

            var deleteImageResult = FileUpload.Delete(result.Data);
            if (!deleteImageResult.Success)
            {
                return deleteImageResult;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == id);
            foreach (var carImage in carImages)
            {
                if (string.IsNullOrEmpty(carImage.ImagePath))
                {
                    carImage.ImagePath = FileUpload.GetDefaultImagePath();
                }
            }
            return new SuccessDataResult<List<CarImage>>(carImages, Messages.ImagesListed);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.Id);
            if (!result.Success)
                return result;


            var updateImage = FileUpload.Update(formFile, result.Data);
            if (!updateImage.Success)
                return updateImage;

            carImage.ImagePath = updateImage.Data;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<string> GetCarImagePathIfExistById(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<string>(Messages.ImageNotFound);
            }
            return new SuccessDataResult<string>(result.ImagePath);
        }
    }
}
