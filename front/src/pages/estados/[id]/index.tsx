import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { EstadoContext } from '../../../contexts/EstadoContext';
import { CidadeContext } from '../../../contexts/CidadeContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import { Header } from '../../../components/Header';
import { FaTrashAlt } from 'react-icons/fa';
import styles from './styles.module.scss';
import { toast } from 'react-toastify';

const EditEstado = () => {
  const { estados, updateEstado, deleteEstado } = useContext(EstadoContext)!;
  const { cidades } = useContext(CidadeContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [nome, setNome] = useState('');
  const [uf, setUf] = useState('');
  const [icmsLocal, setIcmsLocal] = useState('');
  const [icmsExterno, setIcmsExterno] = useState('');
  const [loading, setLoading] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [hasAssociatedCities, setHasAssociatedCities] = useState(false);

  useEffect(() => {
    const estado = estados.find((e) => e.codigo === Number(id));
    if (estado) {
      setNome(estado.nome);
      setUf(estado.uf);
      setIcmsLocal(String(estado.icmsLocal));
      setIcmsExterno(String(estado.icmsExterno));

      // Verifica se há cidades associadas
      const associatedCities = cidades.some(
        (cidade) => cidade.codigoDoEstado === Number(id)
      );
      setHasAssociatedCities(associatedCities);
    }
  }, [id, estados, cidades]);

  const handleUpdateEstado = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updateEstado(Number(id), {
        nome,
        uf,
        icmsLocal: parseFloat(icmsLocal),
        icmsExterno: parseFloat(icmsExterno),
      });

      toast.success('Estado atualizado com sucesso!');
      router.push('/estados');
    } catch (error) {
      console.error('Erro ao atualizar estado:', error);
      toast.error('Erro ao atualizar estado.');
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteEstado = async () => {
    if (hasAssociatedCities) {
      toast.error('O estado possui cidades associadas e não pode ser excluído.');
      return;
    }

    try {
      await deleteEstado(Number(id));
      toast.success('Estado excluído com sucesso!');
      router.push('/estados');
    } catch (error) {
      console.error('Erro ao excluir estado:', error);
      toast.error('Erro ao excluir estado.');
    } finally {
      setShowDeleteModal(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.editEstadoContainer}>
          <div className={styles.titleContainer}>
          </div>
          <div className={styles.trashContainer}>
            <h1>Editar Estado</h1>
            <FaTrashAlt
              className={styles.trashIcon}
              onClick={() => setShowDeleteModal(true)}
              />
            </div>
          <form onSubmit={handleUpdateEstado} className={styles.form}>
            <div className={styles.formGroup}>
              <label htmlFor="nome">Nome do Estado</label>
              <input
                id="nome"
                type="text"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="uf">UF</label>
              <input
                id="uf"
                type="text"
                value={uf}
                onChange={(e) => setUf(e.target.value)}
                maxLength={2}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="icmsLocal">ICMS Local (%)</label>
              <input
                id="icmsLocal"
                type="number"
                step="0.01"
                value={icmsLocal}
                onChange={(e) => setIcmsLocal(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="icmsExterno">ICMS Externo (%)</label>
              <input
                id="icmsExterno"
                type="number"
                step="0.01"
                value={icmsExterno}
                onChange={(e) => setIcmsExterno(e.target.value)}
                required
              />
            </div>

            <div className={styles.buttonGroup}>
              <Button type="submit" loading={loading}>
                Atualizar Estado
              </Button>
            </div>
          </form>
        </div>

        {showDeleteModal && (
          <div className={styles.modalBackdrop}>
            <div className={styles.modal}>
              <h2>Confirmar Exclusão</h2>
              <p>
                Tem certeza que deseja excluir este estado? Esta ação não pode ser
                desfeita.
              </p>
              <div className={styles.modalActions}>
                <Button
                  onClick={handleDeleteEstado}
                  style={{ backgroundColor: '#dc3545' }}
                >
                  Confirmar
                </Button>
                <Button
                  onClick={() => setShowDeleteModal(false)}
                  className={styles.cancelButton}
                >
                  Cancelar
                </Button>
              </div>
            </div>
          </div>
        )}
      </>
    </MainLayout>
  );
};

export default EditEstado;
